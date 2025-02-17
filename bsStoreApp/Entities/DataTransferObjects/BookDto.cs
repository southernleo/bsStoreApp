namespace Entities.DataTransferObjects
{

    public record BookDto()
    {
        public int Id { get; init; }

        public string Title { get; init; }
        public int Price { get; init; }

    }
   
}
