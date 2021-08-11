﻿using System;
using System.Collections.Generic;
using System.IO;
using Persistence; // imported as an externally referenced project (via dependencies of main app NotesApp)
using Persistence.Models;
using Persistence.Repositories;

namespace csharp_notepad_crud_3layer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*

            fileClient.WriteAll("notes.txt", notes); // <T> type is defined according to the type of parameter (notes is of type Note, hence T = Note)

            var notesFromFile = fileClient.ReadAll<Note>("notes.txt");

            foreach (var note in notesFromFile)
            {
                Console.WriteLine(note.Text);
            }*/

            /*var note = new Note
            {
                Id = 2,
                Title = "Second note",
                Text = "Text of second note",
                DateCreated = DateTime.Now
            };

            var fileClient = new FileClient();

            var notesRepository = new NotesRepository(fileClient);

            //notesRepository.Save(note);

            //notesRepository.Edit(1, "Updated title", "Updated text");

            var retrieveNote = notesRepository.GetAll();

            foreach (var retrievedNote in retrieveNote)
            {
                Console.WriteLine(note.Id);
                Console.WriteLine(note.Title);
                Console.WriteLine(note.Text);
                Console.WriteLine(note.DateCreated);
            }*/

            var fileClient = new FileClient();

            var notesRepository = new NotesRepository(fileClient);

            var noteApp = new NoteApp(notesRepository);

            noteApp.Start();
        }
    }
}