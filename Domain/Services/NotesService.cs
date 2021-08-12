using Persistence.Models;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository _notesRepository;
        private readonly List<string> _swearWords;

        public NotesService(NotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
            _swearWords = new List<string>
            {
                "Car",
                "Tree",
                "Walk",
                "Dog",
                "Dirty"
            };
        }

        public IEnumerable<Note> GetAll()
        {
            return _notesRepository.GetAll();

            /*            var allNotes = _notesRepository.GetAll();
                        var validNotes = allNotes.Where(note => note.Text.Length >= 1);

                        return validNotes;*/
        }

        public void Create(Note note)
        {
            if (_swearWords.Any(swearWord => note.Text.Contains(swearWord)))
            {
                throw new Exception("Note is invalid!");
            }

            _notesRepository.Save(note);
        }

        public void Edit(int id, string title, string text)
        {
            _notesRepository.Edit(id, title, text);
        }

        public void DeleteById(int id)
        {
            _notesRepository.Delete(id);
        }

        public void ClearAll()
        {
            _notesRepository.DeleteAll();
        }
    }
}