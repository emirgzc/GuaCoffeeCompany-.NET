using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IVideoService
	{
        List<Video> GetAll();
        List<Video> GetListStatusTrue();
        List<Video> GetOrderByDate();
        List<Video> GetVideoByID(int id);
        Video GetByID(int id);
        void VideoAdd(Video video);
        void VideoUpdate(Video video);
        void VideoDelete(Video video);
    }
}
