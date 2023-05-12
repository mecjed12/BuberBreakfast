using System;
using ErrorOr;

namespace Buberbreakfast.Service.Breakfasts;

    public interface IBreakfastService
    {
        ErrorOr<Breakfast> GetBreakfast(Guid id);
        void CreateBreakfast(Breakfast breakfast);
        void UpsertBreakfast(Breakfast breakfast);
        void DeleteBreakfast(Guid id);
    }




