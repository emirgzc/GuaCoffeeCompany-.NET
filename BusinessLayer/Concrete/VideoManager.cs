using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class VideoManager : IVideoService
	{
		IVideoDal _videoDal;

		public VideoManager(IVideoDal videoDal)
		{
			_videoDal = videoDal;
		}

		public void VideoAdd(Video video)
		{
			_videoDal.Add(video);
		}

		public void VideoDelete(Video video)
		{
			_videoDal.Delete(video);
		}

		public void VideoUpdate(Video video)
		{
			_videoDal.Update(video);
		}

		public List<Video> GetAll()
		{
			return _videoDal.GetAll();
		}

		public Video GetByID(int id)
		{
			return _videoDal.Get(x => x.VideoID == id);
		}

		public List<Video> GetVideoByID(int id)
		{
			return _videoDal.GetAll(x => x.VideoID == id);
		}

		public List<Video> GetListStatusTrue()
		{
			return _videoDal.GetAll(x => x.Status == true).OrderByDescending(z => z.DateVideo).ToList();
		}

		public List<Video> GetOrderByDate()
		{
			return _videoDal.GetAll().OrderByDescending(z => z.DateVideo).ToList();
		}
	}
}
