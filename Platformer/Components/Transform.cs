using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Platformer.Components
{
    class Transform : Component, INotifyPropertyChanged
    {
        private Vector2 _lastValidPosition;
        private Vector2 _position;
        private Vector2 _moveBy;

        public event PropertyChangedEventHandler PropertyChanged;

        public Vector2 LastValidPosition
        {
            get { return _lastValidPosition; }
            set
            {
                _lastValidPosition = value;
            }
        }

        public Vector2 MoveBy
        {
            get { return _moveBy; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                LastValidPosition = _position;
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
        public Vector2 Scale { get; set; }
        public float Rotation { get; set; }

        public Transform()
        {
            ComponentRegistry.Register<Transform>(this);
            _moveBy = Vector2.Zero;
        }

        public void Move(Vector2 moveBy, GameTime gameTime)
        {
            _moveBy += CalculateVelocity(moveBy, gameTime);
            //Position += CalculateVelocity(moveBy, gameTime);
        }

        public void OverrideMovement(Vector2 moveBy, GameTime gameTime)
        {
            //_moveBy = moveBy;
            Position = CalculateVelocity(moveBy, gameTime);
        }

        public void OverrideVerticalMovement(float moveByY, GameTime gameTime)
        {
            _moveBy.Y = CalculateVelocity(new Vector2(0, moveByY), gameTime).Y;
            //_position.Y = CalculateVelocity(new Vector2(0, moveByY), gameTime).Y;
        }

        public void CommitMovement(GameTime gameTime)
        {

            //Position += _moveBy * elapsed;
            Position += _moveBy; //CalculateNextPosition(gameTime);
            _moveBy.X = 0;
            //ClearMovement();
        }

        public Vector2 CalculateNextPosition(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            return Position + _moveBy * elapsed;
        }

        public Vector2 CalculateVelocity(Vector2 moveBy, GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            return moveBy * elapsed;
        }

        public void ClearMovement()
        {
            _moveBy = Vector2.Zero;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
