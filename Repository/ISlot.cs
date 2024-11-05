using MPE.Models;

namespace MPE.Repository
{
    public interface ISlot
    {

        Task<List<Slot>> GetAllSlotAsync();

        Task<Slot> GetSlotByIdAsync(Guid  slotId);

        Task<Slot> CreateSlotAsync(Slot slot);
        

        Task<Slot> UpdateSlotAsync(Slot slot,Guid id);

        Task<Slot> DeleteSlotAsync(Guid slotId);

       



    }
}
