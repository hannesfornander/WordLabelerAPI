using System.Collections.Generic;
using WordLabelerAPI.Models;

namespace WordLabelerAPI.Data
{
    public interface IWordLabelRepository
    {
        IEnumerable<WordLabel> GetAllWordLabels();
        WordLabel GetWordLabelById(int id);
        Word CreateWordLabel(WordLabel wordLabel);
        IEnumerable<WordLabel> GetWordLabelsFromSentence(Sentence sentence);
    }
}