using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public Guid QuestionSetId { get; set; }
    }
}
