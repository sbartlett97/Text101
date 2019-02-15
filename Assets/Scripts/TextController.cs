using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

    public Text text;

    private enum states {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridoor_0, stairs_0,
                        floor, closet_door, corridoor_1, stairs_1, in_closet, corridoor_2, stairs_2, corridoor_3, pick_lock, freedom };
    private states MyState;

	// Use this for initialization
	void Start () {
        MyState = states.cell;
	}
	
	// Update is called once per frame
	void Update () {
       if(MyState == states.cell) {state_Cell();}
       else if (MyState == states.sheets_0) { state_sheets_0(); }
       else if (MyState == states.mirror) { state_mirror(); }  
       else if (MyState == states.lock_0){ state_lock_0(); }
       else if (MyState == states.cell_mirror ){ state_cell_mirror(); }
       else if (MyState == states.lock_1) { state_lock_1(); }
       else if (MyState == states.sheets_1){ state_sheets_1(); }
       else if (MyState == states.corridoor_0) { state_corridoor_0();  }
       else if (MyState == states.stairs_0) { state_stairs_0(); }
       else if (MyState==states.closet_door) { state_closet_door(); }
       else if (MyState == states.floor) { state_floor(); }
       else if (MyState == states.corridoor_1) { state_corridoor_1(); }
       else if (MyState == states.stairs_1) { state_stairs_1(); }
       else if (MyState==states.pick_lock) { state_pick_lock(); }
       else if (MyState == states.in_closet) { state_in_closet(); }
       else if (MyState == states.corridoor_2) { state_corridoor_2(); }
       else if (MyState == states.stairs_2) { state_stairs_2(); }
       else if (MyState == states.corridoor_3) { state_corridoor_3(); }
       else if (MyState == states.freedom) { state_freedom(); }
    }




    void state_Cell()
    {
        text.text = "You are in a prison cell, and you want to escape. There are " +
                        "some dirty sheets on the bed, a mirror on the wall and the door " +
                        "is locked from the outside.\n\n" +
                        "Press 'S' to view the Sheets, Press 'M' to view the Mirror, Press 'L' to View the Lock.";
        if (Input.GetKeyDown(KeyCode.S))
        {
            MyState = states.sheets_0;
        }else if (Input.GetKeyDown(KeyCode.M))
        {
            MyState = states.mirror;
        }else if (Input.GetKeyDown(KeyCode.L))
        {
            MyState = states.lock_0; 
        }
    }

    void state_sheets_0()
    {
        text.text = "You can't believe you sleep in these things. Surely " +
                    "it's time someone chenged them! The pleasures of prison life " +
                    "I guess!\n\n" +
                    "Press 'R' to Return to roaming your cell.";
        if (Input.GetKeyDown(KeyCode.R))
        {
            MyState = states.cell;
        }
    }

    void state_mirror()
    {
        text.text = "There is an old brocken mirror on the wall.\n\n " +
                    "Press 'T' to take a shard out of the mirror.";
        if (Input.GetKeyDown(KeyCode.T))
        {
            MyState = states.cell_mirror;
        }
    }

    void state_lock_0()
    {
        text.text = "There is an old rusty lock on the cell door. If only there was " +
                    "something you could force it open with.\n\n" +
                    "Press 'R' to return to roaming your cell.";
        if (Input.GetKeyDown(KeyCode.R))
        {
            MyState = states.cell;
        }

    }

    void state_cell_mirror()
    {
        text.text = "You are in a prison cell and want to escape. You are holding " +
                    "a shard from a broken mirror. There are some dirty sheets on the bed, " +
                    "and the door is locked from the outside.\n\n" +
                    "Press 'S' to view the sheets, or 'L' to examine the Lock.";
        if (Input.GetKeyDown(KeyCode.L))
        {
            MyState = states.lock_1;
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            MyState = states.sheets_1;
        }

    }

    void state_lock_1()
    {
        text.text = "The lock on the door is old and rusted, it looks like it can be " + 
                    "forced open!\n\n" + 
                    "Force the mirror sshard into the lock? (Y/N)";
        if (Input.GetKeyDown(KeyCode.Y)){ MyState = states.corridoor_0;}
        else if (Input.GetKeyDown(KeyCode.N)){ MyState = states.cell_mirror; }        
    }

    void state_sheets_1()
    {
        text.text = "You can't believe you sleep in these things. Surely " +
                   "it's time someone chenged them! The pleasures of prison life " +
                   "I guess. If only there was a way to escape!\n\n" +
                   "Press 'R' to Return to roaming your cell.";
        if (Input.GetKeyDown(KeyCode.R))
        {
            MyState = states.cell_mirror;
        }
    }

    void state_corridoor_0()
    {
        text.text = "You find youself in a corridoor full of empty cells. Life in this prison isn't " +
                    "all that communal and friendly. Around you, you see a flight of stairs and a janitors closet.\n\n"+
                    "press 'S' to inspect the stairs, " + 
                    "Press 'F' to inspect the Floor, "  +
                    "Press 'C' to inspect the closet door.";

        if (Input.GetKeyDown(KeyCode.S)) { MyState = states.stairs_0; }
        else if (Input.GetKeyDown(KeyCode.F)) { MyState = states.floor; }
        else if (Input.GetKeyDown(KeyCode.C)) { MyState = states.closet_door; }

    }
   
    void state_stairs_0()
    {
        text.text = "At the top of the stairs there is an unlocked door! You can hear " +
                    "some guards talking the other side of it, better not go throuhg there!\n\n" +
                    "Press 'R' to Rreturn to the Corridoor.";
        if (Input.GetKeyDown(KeyCode.R)) { MyState = states.corridoor_0; }
    }

    void state_closet_door()
    {
        text.text = "The Janitors closet is locked tight, it may be possible to pick the lock " +
                    "if you had something small enough...\n\n" +
                    "Press 'R' to Return to searching the corridoor.";
        if (Input.GetKeyDown(KeyCode.R)) { MyState = states.corridoor_0; }
    }

    void state_floor()
    {
        text.text = "You see an old hairclip on the floor, some careless guard must have dropped it!\n\n" +
                    "Press 'H' to pick up the Hairclip or 'R' to continue to looking around the corridoor.";
        if (Input.GetKeyDown(KeyCode.H)) { MyState = states.corridoor_1; }
        else if (Input.GetKeyDown(KeyCode.R)) { MyState = states.corridoor_0; }
    }

    void state_corridoor_1()
    {
        text.text = "The corridoor hasn't changed in the time you've been standing in it. The walls are still " +
                    "damp and drap, and the stoneey floor is freezing. You are now armed with a Hairclip.\n\n"+
                    "Press 'S' to re-inspect the stairs, or 'C' to view the closet door again.";
        if (Input.GetKeyDown(KeyCode.S)) { MyState = states.stairs_1; }
        else if (Input.GetKeyDown(KeyCode.C)) { MyState = states.pick_lock; };
    }

    void state_stairs_1()
    {
        text.text = "Despite wishing against all hope, there are still some pesky guards having a chat behind " +
                    "the door at the top of the stairs. I wonder what could be so interesting?\n\n" +
                    "Press 'R' to return, yet again, to the corridoor.";
        if (Input.GetKeyDown(KeyCode.R)) { MyState = states.corridoor_1; }
    }

    void state_pick_lock()
    {
        text.text = "The lock on the closet is as old and rusty as the one on your cell was, it shouldn't " +
                    "take long to pick it.\n\n" +
                    "Would you like to pick the lock? (Y/N)";
        if (Input.GetKeyDown(KeyCode.Y)) { MyState = states.in_closet; }
        else if (Input.GetKeyDown(KeyCode.N)) { MyState = states.corridoor_1; }
    }

    void state_in_closet()
    {
        text.text = "The Janitors closet smell shorribly of damp! There is a lot of disused cleaning " +
                    "equipment piled up each wall. On the back of the door there is an old janitors " +
                    "jumpsuit, it would make the perfect disuise! If it wasn't for a few holes nibbled by mice..\n\n" +
                    "Press 'D' to get dressed in the Janitors jumpsuit, or Press 'R' to return to the corridoor.";
        if (Input.GetKeyDown(KeyCode.D)) { MyState = states.corridoor_3; }
        else if (Input.GetKeyDown(KeyCode.R)) { MyState = states.corridoor_2; }
    }

    void state_corridoor_2()
    {
        text.text = "Back in the corridoor, the smell from the Janitors closet is beginning to waft around, " +
                    "and a few mice are scurrying around the empty cells. \n\n" +
                    "Press 'S' to yet again inspect the exact same stairs, or Prss 'C' to re-enter the smelly closet.";
        if (Input.GetKeyDown(KeyCode.S)) { MyState = states.stairs_2; ; }
        else if (Input.GetKeyDown(KeyCode.C)) { MyState = states.in_closet; }
    }

    void state_stairs_2()
    {
        text.text = "Somehow the two guards that were talking have multiplyed into 4! " +
                    "Don't these idiots have anything better to do than stand around and chat? " +
                    "Something like catch potential escapees? \n\n"+
                    "Press 'R' to Return to the now smelly corridoor.";
        if (Input.GetKeyDown(KeyCode.R)) { MyState = states.corridoor_2; }
    }

    void state_corridoor_3()
    {
        text.text = "The Jumpsuit is a bit of a tight fit, but fortunately the holes don't show too much of your orange jumpsuit underneath. " +
                    "The smell in the corriddor is now unbearable, almost as if something had died in that closet long ago. " +
                    "You should probably try and get out of here before someone comes to investigate.\n\n" +
                    "Press 'S' to climb the stairs for the last time.";
        if (Input.GetKeyDown(KeyCode.S)) { MyState = states.freedom; }
    }

    void state_freedom()
    {
        text.text = "After climbing the stairs for what feels like the thousandth time, you find yorself in " +
                    "an open air courtyard. You quickly locate the nearest maintnece exit and make your way to it " +
                    "and to your freedom. \n\n" +
                    "Congratulations, you escaped the prison!!\n\n" + 
                    "Press SPACE to start again!";
        if(Input.GetKeyDown(KeyCode.Space)){Start();}
    }
}
