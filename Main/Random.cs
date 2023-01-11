class Random{
    public static int Range(int start, int end){
        System.Random rnd = new System.Random();
        return rnd.Next(start,end);

    }
}