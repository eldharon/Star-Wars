using Star_Wars.Model;
using Star_Wars.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Star_Wars.Paginate
{
    public class Pagination
    {
        public static PaginationResultSetModel PaginateForResult(PagingParameterModel pagingParameterModel, List<CharacterEpisodeDTO> input)
        {

            int count = input.Count();
            int CurrentPage = pagingParameterModel.PageNumber;
            int PageSize = pagingParameterModel.PageSize;
            int TotalCount = count;
            int TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            var elements = input.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            var PreviousPage = CurrentPage > 1 ? "Yes" : "No";
            var NextPage = CurrentPage < TotalPages ? "Yes" : "No";
            PaginationModel paginationMetadata = new PaginationModel
            {
                totalCount = TotalCount,
                pageSize = PageSize,
                currentPage = CurrentPage,
                totalPages = TotalPages,
                previousPage = PreviousPage,
                nextPage = NextPage
            };
            PaginationResultSetModel output = new PaginationResultSetModel
            {
                paginationModel = paginationMetadata,
                items = elements
            };
            return output;
        }
    }
}