using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordLabelerAPI.Dtos;
using WordLabelerAPI.Models;

namespace WordLabelerAPI.Data
{
    public class WordLabelRepository : IWordLabelRepository
    {
        private readonly WordLabelerContext _context;

        public WordLabelRepository(WordLabelerContext context)
        {
            _context = context;
        }

        public IEnumerable<WordLabel> GetAllWordLabels()
        {
            // TODO: Should be a better way to do this
            var labels = _context.Labels.ToList();
            var words = _context.Words.ToList();
            var wordLabels = new List<WordLabel>();

            foreach (var word in words)
            {
                var label = labels.FirstOrDefault(x => x.LabelId == word.LabelId);

                wordLabels.Add(new WordLabel
                {
                    Id = word.WordId,
                    Word = word.WordText,
                    Label = label.LabelName
                });
            }

            return wordLabels;
        }

        public WordLabel GetWordLabelById(int id)
        {
            var word = _context.Words.FirstOrDefault(x => x.WordId == id);
            var label = _context.Labels.FirstOrDefault(x => x.LabelId == word.LabelId);

            var wordLabel = new WordLabel
            {
                Id = word.WordId,
                Word = word.WordText,
                Label = label.LabelName
            };

            return wordLabel;
        }

        public Word CreateWordLabel(WordLabel wordLabel)
        {
            var label = _context.Labels.FirstOrDefault(x => x.LabelName == wordLabel.Label);

            var word = new Word
            {
                WordText = wordLabel.Word,
                LabelId = label.LabelId
            };

            if (_context.Words.FirstOrDefault(x => x.WordText == word.WordText && x.LabelId == word.LabelId) == null)
            {
                _context.Words.Add(word);
                _context.SaveChanges();
            }

            return word;
        }

        public IEnumerable<WordLabel> GetWordLabelsFromSentence(Sentence sentence)
        {
            // TODO: Should be a better way to do this
            var labels = _context.Labels.ToList();
            var words = _context.Words.ToList();
            var wordLabels = new List<WordLabel>();

            // Probably bad code...
            var wordList = sentence.Text.Split(" ");
            foreach (var item in wordList)
            {
                var word = words.FirstOrDefault(x => x.WordText == item);
                if (word != null)
                {
                    var label = labels.FirstOrDefault(x => x.LabelId == word.LabelId);

                    wordLabels.Add(new WordLabel
                    {
                        Id = word.WordId,
                        Word = word.WordText,
                        Label = label.LabelName
                    });
                }
                else
                {wordLabels.Add(new WordLabel
                    {
                        Id = -1,
                        Word = item,
                        Label = "notfound"
                    });
                }
                
            }

            return wordLabels;

        }
    }
}
