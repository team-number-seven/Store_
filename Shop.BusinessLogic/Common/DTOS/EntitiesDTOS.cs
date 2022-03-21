using System;

namespace Store.BusinessLogic.Common.DTOS
{
    public static class EntitiesDTOS
    {
        public record CountryDTO(Guid Id, string Name);

        public record GenderDTO(Guid Id, string Title);
    }
}
