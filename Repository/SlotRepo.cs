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
        public async Task<Slot> CreateSlotAsync(Slot slot)
        {
            await dbContext.slots.AddAsync(slot);
            await dbContext.SaveChangesAsync();

            return slot;
                
                }

        public async Task<Slot> DeleteSlotAsync(Guid slotId)
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

        public async Task<List<Slot>> GetAllSlotAsync()
        {
          var allSlots=  await dbContext.slots.ToListAsync();
            return allSlots;
        }

        public async Task<Slot> GetSlotByIdAsync(Guid slotId)
        {
            var slot = await dbContext.slots.FirstOrDefaultAsync(x=>x.SlotId ==slotId);

            if (slot == null) {

                return null;
            }
            return slot;
        }

      
        public async Task<Slot> UpdateSlotAsync(Slot slot,Guid id)
        {

            var Currentslot = await dbContext.slots.FirstOrDefaultAsync (x=>x.SlotId==id);

            if (Currentslot == null) {
                return null;
            }

            Currentslot.ProductId=slot.ProductId;
            Currentslot.MaximumSlotSize=slot.MaximumSlotSize;
            Currentslot.DiscountInPercent=slot.DiscountInPercent;
            Currentslot.CurrentSlotSize=slot.CurrentSlotSize;

          await  dbContext.SaveChangesAsync();

            return Currentslot;


            
        }

      
    }
}
