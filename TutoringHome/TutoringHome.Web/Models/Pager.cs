using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace TutoringHome.Web.Models
{
    public class Pager
    {
        private int _pageSize = 15;

        public RouteValueDictionary UrlParams { get; set; }

        /// <summary>
        /// 分页数量
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 分页总数
        /// </summary>
        public int PageCnt
        {
            get
            {
                return (int)Math.Ceiling((double)this.Count / (double)this.PageSize);
            }
        }

        private int _renderLength = 10;

        public void SetRenderLength(int renderLength)
        {
            _renderLength = renderLength;
        }

        /// <summary>
        /// 获取可以输出到页面上的页码
        /// </summary>
        /// <returns></returns>
        public List<PageIndex> RenderPagerIndex()
        {
            List<PageIndex> arrIndex = new List<PageIndex>();
            if (this.PageIndex > 1)
            {
                PageIndex index = new PageIndex();
                index.Index = PageIndex - 1;
                index.Text = "<b class=\"left\"></b>";
                index.LinkClass = "class=page-ctrl";
                arrIndex.Add(index);
            }
            arrIndex.Add(new PageIndex { Index = 1 });
            if ((PageIndex - (_renderLength / 2) >= 2))
            {
                arrIndex.Add(new PageIndex { Index = -1, Text = "..." });
            }
            int _begin = Math.Max(PageIndex - (_renderLength / 2) + 1, 2);

            int begin = Math.Min(_begin, PageCnt - _renderLength + 2);
            for (int i = 0; i < (_renderLength - 1); i++)
            {
                int j = begin + i;
                if (PageCnt < j) { break; }
                if (j > 1)
                {
                    arrIndex.Add(new PageIndex { Index = j });
                }
            }
            if (PageCnt > _renderLength && PageCnt > Convert.ToInt32(arrIndex.Last().Index))
            {
                arrIndex.Add(new PageIndex { Index = -1, Text = "..." });
            }
            if (PageCnt > PageIndex)
            {
                PageIndex index = new PageIndex();
                index.Index = PageIndex + 1;
                index.Text = "<b class=\"right\"></b>";
                index.LinkClass = "class=page-ctrl";
                arrIndex.Add(index);
            }
            return arrIndex;
        }
    }
    public class PageIndex
    {
        private string _text;

        public int Index { get; set; }

        public string Text
        {
            get
            {
                if (string.IsNullOrEmpty(_text))
                {
                    return Index.ToString();
                }
                else
                {
                    return _text;
                }
            }
            set
            {
                _text = value;
            }
        }

        public string LinkClass { get; set; }


    }
}