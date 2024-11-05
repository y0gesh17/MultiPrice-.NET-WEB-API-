using MPE.Models;

namespace MPE.Repository
{
    public interface ISlot
    {

        Task<List<Slot>> GetAllSlot();

        Task<Slot> GetSlotById(Guid  slotId);

        Task<Slot> CreateSlot(Slot slot);
        

        Task<Slot> UpdateSlot(Slot slot,Guid id);

        Task<Slot> DeleteSlot(Guid slotId);

       



    }
}
