class House
{
    private List<Room> _rooms = new List<Room>();

    public House(List<Room> rooms)
    {
        _rooms = rooms;
    }

    public List<Room> getRooms()
    {
        return _rooms;
    }


}