using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;

namespace 퀵드로우
{
    public class QD_Drawing     // 각 퀵드로우 데이터를 표현하는 객체
    {
        public string Word { get; set; }
        public List<List<List<int>>> Drawing { get; set; }
        // List<List<int>> 형식으로 그림 좌표 데이터 저장
    }

    //public class QD_Loader  // NDJSON 파일을 읽어 데이터를 로드
    //{
    //    public List<QD_Drawing> LoadData(string filePath)   // NDJSON 데이터를 로드하고 리스트로 반환
    //    {
    //        var drawings = new List<QD_Drawing>();

    //        foreach (var line in File.ReadLines(filePath))  // // 파일의 각 줄을 읽어들여 처리
    //        {
    //            var drawing = JsonConvert.DeserializeObject<QD_Drawing>(line);
    //            // JSON 형식의 문자열을 QD_Drawing 객체로 변환
    //            drawings.Add(drawing);
    //        }

    //        return drawings;
    //    }
    //}

    public class QD_Loader
    {
        public async Task<List<QD_Drawing>> LoadDataAsync(string filePath)
        {
            var drawings = new List<QD_Drawing>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var drawing = JsonConvert.DeserializeObject<QD_Drawing>(line);
                    drawings.Add(drawing);
                }
            }

            return drawings;
        }
    }
}