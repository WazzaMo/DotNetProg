using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class RoomGame {
    private NamedGraphNode<string> _CurrentRoom;

    public RoomGame() {
        SetupRooms();
    }

    public void SetupRooms() {
        NamedGraphNode<string>
            NorthRoom = new NamedGraphNode<string>("North Room"),
            NorthEastRoom = new NamedGraphNode<string>("North East Room"),
            NorthSouthCorridor = new NamedGraphNode<string>("North South Corridor"),
            SouthernKitchen = new NamedGraphNode<string>("Southern Kitchen"),
            SouthWestWing = new NamedGraphNode<string>("South West Wing");
        
        NorthRoom
            .AddNeighbour(NorthEastRoom)
            .AddNeighbour(NorthSouthCorridor);
        SouthernKitchen
            .AddNeighbour(NorthSouthCorridor)
            .AddNeighbour(SouthWestWing);
        _CurrentRoom = NorthSouthCorridor;
    }

    public void ChooseRoom() {
        int choice;
        Func<int,int> IndexToChoice = (int aChoice) => aChoice + 1;
        Func<int,int> ChoiceToIndex = (int anIndex) => anIndex - 1;

        System.Console.WriteLine("Choose a new room:");
        string[] rooms = _CurrentRoom.Neighbours().ToArray();
        for(var index = 0; index < rooms.Length; index++) {
            System.Console.WriteLine( $"# {IndexToChoice(index)} : {rooms[index]}");
        }
        choice = GetValidChoice(1, rooms.Length);
        NamedGraphNode<string> ChosenRoom;
        if( _CurrentRoom.GetNeighbour( rooms[ ChoiceToIndex(choice)], out ChosenRoom ) ) {
            _CurrentRoom = ChosenRoom;
            System.Console.WriteLine( $"Entered room {ChosenRoom.Name}");
        } else {
            System.Console.WriteLine( $"Could not enter room {rooms[ChoiceToIndex(choice)]} due to an internal barrier!" );
        }
    }

    private int GetValidChoice(int lowerLimit, int upperLimit) {
        int choice = -1;
        while(choice < lowerLimit || choice > upperLimit) {
            System.Console.WriteLine( $"Choice - enter a number from {lowerLimit} to {upperLimit} #: " );
            if (! Int32.TryParse(Console.ReadLine(), out choice)) {
                System.Console.WriteLine("Please enter a number.");
            }
        }
        return choice;
    }
}