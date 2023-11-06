public class SeatManager 
{
    private bool[] reservedSeatArray;

    public SeatManager(int n) 
    {
        reservedSeatArray = new bool[n];
    }
    
    public int Reserve() 
    {
        int freePlace = Array.IndexOf(reservedSeatArray, false);
        reservedSeatArray[freePlace] = true;
        return freePlace + 1;                                   // [0] index = 1st place
    }
    
    public void Unreserve(int seatNumber) 
    {
        reservedSeatArray[seatNumber - 1] = false;
    }
}

/**
 * Your SeatManager object will be instantiated and called as such:
 * SeatManager obj = new SeatManager(n);
 * int param_1 = obj.Reserve();
 * obj.Unreserve(seatNumber);
 */