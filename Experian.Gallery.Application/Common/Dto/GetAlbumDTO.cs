using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experian.Gallery.Application.Common.Dto
{
    public class GetAlbumDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public IEnumerable<GetPhotoDTO> photos { get; set; }
    }
}
