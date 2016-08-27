using AncientTechnology.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System;
using AncientTechnology.Core.Entities.Material;
using AncientTechnology.Core.Camera;
using AncientTechnology.Core.Entities.Factories;
using Microsoft.Xna.Framework.Graphics;

namespace AncientTechnology.Core.Control.Managers {
    public class MainManager : IUpdateable {
        private ILevelFactory _levelFactory;
        private IList<IUpdateable> _boiler = new List<IUpdateable>();
        private GameLevel _currentLevel;

        public IEnumerable<IVisualObject> VisualObjects {
            get {
                return _boiler.Where(x => x is IVisualObject).Cast<IVisualObject>();
            }
        }

        public GameLevel CurrentLevel {
            get {
                return _currentLevel;
            }
        }

        public MainManager(ILevelFactory levelFactory, GraphicsDevice graphicsDevice) {
            _levelFactory = levelFactory;
        }

        public IEnumerable<IVisualObject> GetObjectsInRectangle(Microsoft.Xna.Framework.Rectangle rectangle) {
            return VisualObjects.Where(o => o.Bounds.Intersects(rectangle));
        }

        public void Add(IUpdateable updateable) {
            _boiler.Add(updateable);
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime) {
            foreach (var updateable in _boiler) {
                updateable.Update(gameTime);
            }
        }

        public void Initialize()
        {
            
        }

        public void LoadLevel(int id) {
            _boiler.Clear();
            _currentLevel = _levelFactory.LoadLevel(id);
            foreach (var obj in _currentLevel.GameObjects) {
                _boiler.Add(obj);
            }
        }

        public void UnloadLevel() {
            // TODO:
            // save items state
            // clear stuff
        }
    }
}
