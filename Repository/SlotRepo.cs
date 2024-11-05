using Microsoft.EntityFrameworkCore;
using MPE.Data;
using MPE.Models;

namespace MPE.Repository
{
    public class SlotRepo : ISlot
    {
        ProductDbContext dbContext;
        public SlotRepo(ProductDbContext dbContext ) {
            this.dbContext = dbContext;
        }
        public async Task<Slot> CreateSlot(Slot slot)
        {
            await dbContext.slots.AddAsync(slot);
            await dbContext.SaveChangesAsync();

            return slot;
                
                }

        public async Task<Slot> DeleteSlot(Guid slotId)
        {
            var slot =await dbContext.slots.FirstOrDefaultAsync(x=>x.SlotId==slotId);

            if (slot == null)
            {
                return null;
            }
            dbContext.slots.Remove(slot);
            await dbContext.SaveChangesAsync();

            return slot;

        }

        public async Task<List<Slot>> GetAllSlot()
        {
          var allSlots=  await dbContext.slots.ToListAsync();
            return allSlots;
        }

        public async Task<Slot> GetSlotById(Guid slotId)
        {
            var slot = await dbContext.slots.FirstOrDefaultAsync(x=>x.SlotId ==slotId);

            if (slot == null) {

                return null;
            }
            return slot;
        }

      
        public Task<Slot> UpdateSlot(Slot slot)
        {
            throw new NotImplementedException();
        }
    }
}
