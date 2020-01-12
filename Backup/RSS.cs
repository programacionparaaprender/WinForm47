#region Using directives

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

#endregion

namespace RssNewsReader
{
    public sealed class ChannelInfo
    {
        private string m_title;
        private string m_link;
        private string m_desc;
        private Uri m_imageUrl;
        private string m_imageLink;

        public ChannelInfo(string title, string link, string description, Uri imageUrl, string imageLink)
        {
            this.m_title = title;
            this.m_link = link;
            this.m_desc = description;
            this.m_imageLink = imageLink;
            this.m_imageUrl = imageUrl;
        }

        public ChannelInfo() : this("", "", "", null, "")
        {
        }

        public string Title
        {
            get
            {
                return m_title;
            }
        }

        public string Link
        {
            get
            {
                return m_link;
            }
        }

        public string Description
        {
            get
            {
                return m_desc;
            }
        }

        public Uri ImageUrl
        {
            get
            {
                return m_imageUrl;
            }
        }

        public string ImageLink
        {
            get
            {
                return m_imageLink;
            }
        }
    }

    public sealed class NewsItem
    {
        private string m_title;
        private string m_link;
        private string m_description;

        public NewsItem(string title, string link, string description)
        {
            this.m_title = title;
            this.m_link = link;
            this.m_description = description;
        }

        public string Title
        {
            get
            {
                return m_title;
            }
        }

        public string Link
        {
            get
            {
                return m_link;
            }
        }

        public string Description
        {
            get
            {
                return m_description;
            }
        }
    }

    internal class FeedReader
    {
        private Uri m_uri;
        private List<NewsItem> m_newsItems;
        private ChannelInfo m_channelInfo;

        internal FeedReader(Uri uri)
        {
            this.m_uri = uri;
        }

        internal void Load()
        {
            m_newsItems = new List<NewsItem>();
            m_channelInfo = new ChannelInfo();

            XmlDocument doc = new XmlDocument();
            using (XmlReader reader = XmlReader.Create(m_uri.AbsoluteUri))
            {
                doc.Load(reader);
                reader.Close();
            }

            XmlNode channelNode = doc.SelectSingleNode("//rss/channel");
            if (channelNode == null)
                throw new RssException("Not a valid RSS channel.");

            XmlNode channelTitleNode = channelNode.SelectSingleNode("title");
            string channelTitle = (channelTitleNode == null) ? "" : channelTitleNode.InnerText;

            XmlNode channelLinkNode = channelNode.SelectSingleNode("link");
            string channelLink = (channelLinkNode == null) ? "" : channelLinkNode.InnerText;

            XmlNode channelDescNode = channelNode.SelectSingleNode("description");
            string channelDesc = (channelDescNode == null) ? "" : channelDescNode.InnerText;

            XmlNode imageLinkNode = channelNode.SelectSingleNode("image/link");
            string imageLink = (imageLinkNode == null) ? "" : imageLinkNode.InnerText;
            
            XmlNode imageUrlNode = channelNode.SelectSingleNode("image/url");
            Uri imageUrl = (imageUrlNode == null) ? null : new Uri(imageUrlNode.InnerText);

            m_channelInfo = new ChannelInfo(channelTitle, channelLink, 
                                             channelDesc, imageUrl, imageLink);

            XmlNodeList items = channelNode.SelectNodes("item");
            foreach (XmlNode itemNode in items)
            {
                XmlNode titleNode = itemNode.SelectSingleNode("title");
                string title = (titleNode == null) ? "" : titleNode.InnerText;

                XmlNode linkNode = itemNode.SelectSingleNode("link");
                string link = (linkNode == null) ? "" : linkNode.InnerText;

                XmlNode descNode = itemNode.SelectSingleNode("description");
                string description = (descNode == null) ? "" : 
                       System.Web.HttpUtility.HtmlDecode(descNode.InnerText);

                m_newsItems.Add(new NewsItem(title, link, description));
            }
        }

        internal List<NewsItem> NewsItems
        {
            get
            {
                return m_newsItems;
            }
        }

        internal ChannelInfo ChannelInfo
        {
            get
            {
                return m_channelInfo;
            }
        }
    }

    [Serializable]
    public class RssException : Exception
    {
        public RssException()
            : base()
        {
        }

        public RssException(string message)
            : base(message)
        {
        }

        public RssException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected RssException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
