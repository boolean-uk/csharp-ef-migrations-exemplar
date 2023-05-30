using ef.intro.wwwapi.Repository;
using ef.intro.wwwapi.Models;

namespace ef.intro.wwwapi.EndPoint
{
    public static class PublisherApi
    {
        public static void ConfigurePublisherApi(this WebApplication app)
        {
            app.MapGet("/publishers", GetAllPublishers);
            app.MapGet("/publishers/{id}", GetPublisher);
            app.MapPost("/publisher", InsertPublisher);
            app.MapPut("/publishers", UpdatePublisher);
            app.MapDelete("/publishers", DeletePublisher);
        }
        private async static Task<IResult> GetAllPublishers(ILibraryRepository service)
        {
            try
            {
                return await Task.Run(() => {
                    return Results.Ok(service.GetAllPublishers());
                });
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private async static Task<IResult> GetPublisher(int id, ILibraryRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var item = service.GetPublisher(id);
                    if (item == null) return Results.NotFound();
                    return Results.Ok(item);
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private async static Task<IResult> DeletePublisher(int id, ILibraryRepository service)
        {
            try
            {
                if (service.DeletePublisher(id)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private async static Task<IResult> UpdatePublisher(Publisher item, ILibraryRepository service)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (service.UpdatePublisher(item)) return Results.Ok();
                    return Results.NotFound();
                });

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private async static Task<IResult> InsertPublisher(Publisher item, ILibraryRepository service)
        {
            try
            {
                if (service.AddPublisher(item)) return Results.Ok();
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }


    }
}
