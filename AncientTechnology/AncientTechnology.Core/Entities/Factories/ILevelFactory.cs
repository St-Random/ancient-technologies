using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientTechnology.Core.Entities.Factories {
    public interface ILevelFactory {
        GameLevel LoadLevel(int levelId, GameLevel currentLevel = null);
    }
}
