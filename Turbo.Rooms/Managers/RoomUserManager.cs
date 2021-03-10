﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Turbo.Core;
using Turbo.Core.Game.Players;
using Turbo.Core.Game.Rooms;
using Turbo.Core.Game.Rooms.Mapping;
using Turbo.Core.Game.Rooms.Object;
using Turbo.Core.Game.Rooms.Utils;
using Turbo.Core.Packets.Messages;
using Turbo.RoomObject.Object;

namespace Turbo.Rooms.Managers
{
    public class RoomUserManager : IAsyncInitialisable, IAsyncDisposable
    {
        private readonly IRoom _room;

        private readonly List<IPlayer> _roomObservers;
        private readonly Dictionary<int, IRoomObject> _roomObjects;
        private int _roomObjectCounter;

        public RoomUserManager(IRoom room)
        {
            _room = room;

            _roomObservers = new List<IPlayer>();
            _roomObjects = new Dictionary<int, IRoomObject>();

            _roomObjectCounter = -1;
        }

        public async ValueTask InitAsync()
        {

        }

        public async ValueTask DisposeAsync()
        {

        }

        public IRoomObject GetRoomObject(int id)
        {
            if (id < 0) return null;

            try
            {
                IRoomObject roomObject;

                if (_roomObjects.TryGetValue(id, out roomObject)) return roomObject;

                return null;
            }

            catch(Exception e)
            {
                return null;
            }
        }

        public IRoomObject GetRoomObjectByUserId(int userId)
        {
            return null;
        }

        public IRoomObject GetRoomObjectByUsername(string username)
        {
            return null;
        }

        public IRoomObject AddRoomObject(IRoomObject roomObject, IPoint location, IPoint direction)
        {
            if (roomObject == null) return null;

            IRoomObject existingRoomObject = GetRoomObject(roomObject.Id);

            if(existingRoomObject != null)
            {
                roomObject.Dispose();

                return null;
            }

            roomObject.SetLocation(location);
            roomObject.SetDirection(direction);

            IRoomTile roomTile = _room.RoomMap.GetTile(roomObject.Location);

            if(roomTile != null)
            {
                roomTile.AddUser(roomObject);
            }

            // invoke the users location

            // COMPOSER: SendComposer(RoomUserComposer(roomObject), RoomUserStatusComposer(roomObject))

            UpdateTotalUsers();

            return roomObject;
        }

        public IRoomObject CreateRoomObjectAndAssign(IRoomObjectHolder roomObjectHolder, IPoint location, IPoint direction)
        {
            if (roomObjectHolder == null) return null;

            IRoomObject roomObject = new RoomObject.Object.RoomObject(_roomObjectCounter++, roomObjectHolder.Type);

            if (roomObject == null) return null;

            if (!roomObjectHolder.SetRoomObject(roomObject)) return null;

            return AddRoomObject(roomObject, location, direction);
        }

        public void EnterRoom()
        {

        }

        private void UpdateTotalUsers()
        {

        }

        public void SendComposer(IComposer composer)
        {
            if (composer == null) return;

            foreach(IPlayer sessionPlayer in _roomObservers)
            {
                // send packet
            }
        }
    }
}
