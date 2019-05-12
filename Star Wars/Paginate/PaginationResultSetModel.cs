using Star_Wars.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Star_Wars.Paginate
{
    public class PaginationResultSetModel
    {
        public PaginationModel paginationModel { get; set; }
        public List<CharacterEpisodeDTO> items { get; set; }
    }
}