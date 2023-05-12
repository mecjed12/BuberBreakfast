using ErrorOr;
using Buberbreakfast.Service;
using Buberbreakfast;

namespace Buberbreakfast.ServiceError;

public static class Errors
{
    public static class Breakfast
    {
        public static Error NotFound => Error.NotFound(
            code: "Breakfast.NotFound",
            description: "Breakfast Not found");   
    }
}