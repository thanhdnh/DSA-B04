public class Program
{
    public static int SeqSearch(int[] arr, int value){
        int i = 0;
        while(arr[i]!=value)
            i++;
        return i;
    }
    public static int SeqSearchLast(int[] arr, int value){
        int i = arr.Length - 1;
        while(arr[i]!=value)
            i--;
        return i;
    }
    public static int RecuSearch(int[] arr, int from, int value){
        if(arr[from]==value)
            return from;
        else
            return RecuSearch(arr, from+1, value);
    }
    public static int RecuSearch2(Array arr, int value){
        //Nếu phần tử đầu tiên bằng value
        if((int)arr.GetValue(arr.GetLowerBound(0))==value)
        //  thì return nó
            return (int)arr.GetLowerBound(0);
        //Ngược lại
        else{
        //  thì tìm kiếm trong phần còn lại của mảng
            //Tạo mảng mới với chỉ số loại chỉ số đầu
            int index = arr.GetLowerBound(0) + 1;
            int len = arr.GetLength(0) - 1;
            Array newarr = Array.CreateInstance(
                                typeof(int),
                                new int[]{len},
                                new int[]{index}
                            );
            Array.Copy(arr, index, newarr, index, len);
            return RecuSearch2(newarr, value);
        }
    }
    public static int SenSearch(int[] arr, int value){
        int x = arr[arr.Length-1];
        arr[arr.Length-1] = value;
        int i = 0;
        while(arr[i]!=value)
            i++;
        arr[arr.Length-1] = x;
        if(i<arr.Length-1 || arr[arr.Length-1]==value)
            return i;
        else
            return -1;
    }
    public static int SenRecuSearch(int[] arr, int from, int value){
        int x = arr[arr.Length-1];
        arr[arr.Length-1] = value;
        if(arr[from]==value){
            if(from<arr.Length-1)
                return from;
            else{
                arr[arr.Length-1] = x;
                if(arr[arr.Length-1]==value)
                    return from;
                else return -1;
            }
        }else{
            arr[arr.Length-1] = x;
            return SenRecuSearch(arr, from+1, value);
        }
    }
    public static int BinSearch(int[] arr, int L, int R, int value){
        while(true){
            int mid = (L+R)/2;
            if(arr[mid]==value)
                return mid;
            else if(value>arr[mid]){
                L = mid + 1;
            }else{
                R = mid - 1;
            }
        }
    }
    public static void Main(string[] args)
    {
        Console.Clear();

        int[] arr = new int[]{3, 5, 6, 9, 12, 15};
        /*Array arr = Array.CreateInstance(typeof(int), 4);
        arr.SetValue(3, 0); arr.SetValue(5, 1);
        arr.SetValue(6, 2); arr.SetValue(9, 3);*/
        int value = 12;
        /*int res = RecuSearch(arr, 0, value);*/
        /*int res = SeqSearch(arr, value);*/
        //int res = RecuSearch2(arr, value);
        //int res = SenSearch(arr, value);
        //int res = SenRecuSearch(arr, 0, value);
        int res = BinSearch(arr, 0, arr.Length-1, value);
        Console.WriteLine($"Vi tri can tim: {res}");

        Console.ReadLine();
    }
}