using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Persistence.Repositories;
using Domain.Services;
using Persistence.Models;

namespace csharp_notepad_crud_3layer
{
    public class NoteApp
    {
        private readonly INotesService _notesService;

        public NoteApp(INotesService notesService)
        {
            _notesService = notesService;
        }

        public void Start()
        {
            string text;
            string title;

            while (true)
            {
                Console.WriteLine("Available commands:");
                Console.WriteLine("1 - Show all notes");
                Console.WriteLine("2 - Create note");
                Console.WriteLine("3 - Edit note");
                Console.WriteLine("4 - Delete note");
                Console.WriteLine("5 - Delete all notes");
                Console.WriteLine("6 - Exit");

                var chosenCommand = Console.ReadLine();
                switch (chosenCommand)
                {
                    case "1":
                        // show all notes

                        break;

                    case "2":
                        Console.WriteLine("Enter note Title:");
                        title = Console.ReadLine();
                        Console.WriteLine("Enter note Text: ");
                        text = Console.ReadLine();
                        _notesService.Create(new Note
                        {
                            Id = 1,
                            Title = title,
                            Text = text,
                            DateCreated = DateTime.Now
                        });
                        // Create note
                        break;

                    case "3":
                        Console.WriteLine("Enter note ID");
                        Console.WriteLine("Enter new note Title");
                        title = (Console.ReadLine());
                        Console.WriteLine("Enter new note Text");
                        text = (Console.ReadLine());
                        // Edit note
                        break;

                    case "4":
                        Console.WriteLine("Enter note ID:");
                        // Delete note
                        break;

                    case "5":
                        // Delete all notes
                        break;

                    case "6":
                        return;
                }
            }
        }
    }
}