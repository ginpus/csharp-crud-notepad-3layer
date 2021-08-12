using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_notepad_crud_3layer
{
    public class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //services.AddSingleton<IFileClient, FileClient>(); // Singleton ~ Static. When IFileClient is requested, FileClient will always be returned

            services.AddTransient<IFileClient, FileClient>(); // everytime a new object gets created. Relevant, when number of clients could be using same class
            services.AddSingleton<INotesRepository, NotesRepository>();
            services.AddSingleton<INotesService, NotesService>();
            services.AddSingleton<NoteApp>();

            return services.BuildServiceProvider();
        }
    }
}