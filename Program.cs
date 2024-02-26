public class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();

        Array ar = Array.CreateInstance(typeof(int), 5);
        ar.SetValue(3, 0); ar.SetValue(7, 1);
        ar.SetValue(8, 2); ar.SetValue(4, 3);
        ar.SetValue(11, 4);
        int value = 4;
        int res = RecuSearch2(ar, value);
        System.Console.WriteLine("Result: {0}", res);

        Console.ReadLine();
    }

    static int SeqSearch(int[] arr, int value)
    {
        /*for (int i = 0; i < arr.Length; i++)
            if (arr[i] == value)
                return i;
        return -1;*/
        /*int i = 0;
        while(arr[i]!=value)
            i++;
        return i;*/
        int i = arr.Length - 1;
        while(arr[i]!=value)
            i--;
        return i;
    }
    static int RecuSearch(int[] arr, int from, int value){
        if(arr[from] == value)
            return from;
        else
            return RecuSearch(arr, from++, value);
    }
    static int RecuSearch2(Array arr, int value){
        if((int)arr.GetValue(arr.GetLowerBound(0))==value)//nếu phần tử đầu tiên của arr bằng value
            return arr.GetLowerBound(0);//thì return chỉ số đầu tiên này
        else{
            //Lấy chỉ số thứ 2 của mảng
            int x = arr.GetLowerBound(0) + 1;
            //Lấy độ dài của phần còn lại của mảng
            int d = arr.GetLength(0) - 1;
            //Tạo mảng mới với chỉ số là từ chỉ số thứ 2
            Array newarr = Array.CreateInstance(
                                typeof(int), 
                                new int[]{d}, 
                                new int[]{x}
                            );
            //Copy các phần tử từ vị trí thứ 2 sang mảng mới
            Array.Copy(arr, x, newarr, x, d);
            //Gọi đệ quy RecuSearch2(mảng_mới, value)
            return RecuSearch2(newarr, value);
        }
    }
}