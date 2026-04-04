//73. Set Matrix Zeroes

public class SetMatrixZeroes {
    public void SetZeroes(int[][] m) {
        HashSet<int> row = new HashSet<int>();
        HashSet<int> col = new HashSet<int>();
        for(int i=0;i<m.Length;i++){
            for(int j=0;j<m[i].Length;j++){
                if(m[i][j]==0){
                    row.Add(i);
                    col.Add(j);
                }
            }
        }foreach(int i in row){
            for(int j=0;j<m[i].Length;j++){
                m[i][j]=0;
            }
        }
        foreach(int i in col){
            for(int j=0;j<m.Length;j++){
                m[j][i]=0;
            }
        }
    }
}