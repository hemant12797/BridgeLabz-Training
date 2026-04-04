//118. Pascal's Triangle

public class PascalsTriangle {
    public IList<IList<int>> Generate(int numRows) {
        IList<IList<int>> list = new List<IList<int>>();
        for(int i=0;i<numRows;i++){
            List<int> ls = new List<int>();
            ls.Add(1);
            for(int j=1;j<i;j++){
                ls.Add(list[i-1][j-1]+list[i-1][j]);
            }
            if(i!=0)ls.Add(1);
            list.Add(ls);
        }return list;
    }
}