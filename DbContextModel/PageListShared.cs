using DbContextModel.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Data.Entity;

namespace DbContextModel
{
    public class PageListShared
    {
        private DbContextWeb context = null;
        private static PageListShared pageListShared;
        private PageListShared()
        {
            context = new DbContextWeb();
        }

        public static PageListShared getInstance()
        {
            if ( pageListShared == null )
            {
                pageListShared = new PageListShared();
            }
            return pageListShared;
        }

        public IEnumerable<ThongTinBDS> ListAllPageThongTinBDS (int page = 1, int rowLimit = 10)
        {
            return context.ThongTinBDS
                .OrderByDescending(tt => tt.MaTin)
                .Include(t => t.Huong)
                .Include(t => t.KhuDanCu)
                .Include(t => t.LoaiBD)
                .Include(t => t.QuanHuyen)
                .Include(t => t.ThongTin)
                .ToPagedList(page, rowLimit);
        }
        public IEnumerable<TaiKhoan> ListAllPageTaiKhoan (int page = 1, int rowLimit = 10)
        {
            return context.TaiKhoans.OrderByDescending(x => x.UserName).ToPagedList(page, rowLimit);
        }
        public IEnumerable<KhuDanCu> ListAllPageKhuDanCu (int page = 1, int rowLimit = 10)
        {
            return context.KhuDanCus.OrderByDescending(x => x.MaKhuDanCu).ToPagedList(page, rowLimit);
        }
    }
}
