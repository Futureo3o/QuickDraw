using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 퀵드로우
{
    public partial class Form1 : Form
    {
        private List<List<Point>> strokes = new List<List<Point>>(); // 여러 개의 선을 저장하는 리스트 (각 선은 Point 객체 리스트로 저장)
        private List<Point> currentStroke = null; // 현재 그리고 있는 선을 저장하는 리스트
        private Pen pen = new Pen(Color.Black, 3); // 선 색상과 두께 설정 (검정 3px)
        private Point? lastPoint = null; // 선을 그릴 때 마지막 좌표를 저장

        private List<string> datasetFiles = new List<string> {
            "../../dataset/full_simplified_airplane.ndjson",
            "../../dataset/full_simplified_ant.ndjson",
            "../../dataset/full_simplified_apple.ndjson",
            "../../dataset/full_simplified_banana.ndjson",
            "../../dataset/full_simplified_bee.ndjson",
            "../../dataset/full_simplified_book.ndjson"
        };

        private string Keyword;

        private Timer drawTimer;
        private int timeRemaining = 20; // 20초 제한 시간

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true; // 더블 버퍼링 활성화 (깜빡거림 방지)

            drawTimer = new Timer();
            drawTimer.Interval = 1000; // 1초마다 타이머 작동
            drawTimer.Tick += DrawTimer_Tick;
            StartGame(); // 게임 시작 설정
        }

        //private void SetRandomKeyword()
        //{
        //    // 난수 생성
        //    Random rand = new Random();
        //    int randomIndex = rand.Next(datasetFiles.Count);

        //    // 랜덤 파일과 키워드 설정
        //    string selectedFile = datasetFiles[randomIndex];
        //    Keyword = selectedFile.Split('_').Last().Replace(".ndjson", "");

        //    // 키워드를 UI에 표시
        //    //MessageBox.Show($"{Keyword}를 그리세요!");
        //    lblText.Text = $"{Keyword} 그리기";

        //    // 선택한 파일로부터 데이터 로드
        //    var loader = new QD_Loader();
        //    var drawings = loader.LoadData(selectedFile);
        //}

        private async Task SetRandomKeywordAsync()
        {
            Random rand = new Random();
            int randomIndex = rand.Next(datasetFiles.Count);

            string selectedFile = datasetFiles[randomIndex];
            Keyword = selectedFile.Split('_').Last().Replace(".ndjson", "");
            lblText.Text = $"{Keyword} 그리기";

            // 비동기 로드
            var loader = new QD_Loader();
            var drawings = await loader.LoadDataAsync(selectedFile);
            // drawings 로드 후에 필요한 후속 작업 수행 가능
        }

        //private void StartGame()    // 타이머 시작 메서드
        private async void StartGame()
        {
            //SetRandomKeyword(); // 랜덤 키워드 설정 메서드 호출
            await SetRandomKeywordAsync();
            strokes.Clear(); // 기존 그림 지우기
            timeRemaining = 20;
            drawTimer.Start();
        }

        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            timeRemaining--;
            lblTimer.Text = $"00 : {timeRemaining:D2}"; // D2 : 2자리 숫자로 표시
            if (timeRemaining <= 0)
            {
                drawTimer.Stop();
            }
        }

        // 마우스를 누를 때 새로운 선을 시작
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // 새로운 선 시작
            if (e.Button == MouseButtons.Left)
            {
                currentStroke = new List<Point>();  // 새로운 선을 위한 리스트 초기화
                currentStroke.Add(e.Location);  // 현재 좌표를 첫 번째 점(시작점)으로 추가
                lastPoint = e.Location; // 시작점 설정
            }
        }

        // 마우스를 움직일 때 선에 좌표를 계속 추가
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // 선에 좌표 추가
            if (currentStroke != null)  // 선을 그리고 있을 때만 실행
            {
                // 이전 점과 현재 점 사이의 거리 계산 (거리 기준으로 점을 추가)
                var distance = GetDistance(lastPoint.Value, e.Location);

                // 매번 이동할 때마다 점을 추가
                currentStroke.Add(e.Location); // 새로운 점 추가
                lastPoint = e.Location; // 마지막 점 업데이트

                this.Invalidate(); // 화면 갱신
            }
        }

        // 마우스를 뗄 때 선을 마무리
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentStroke != null) // 선이 존재할 때만 실행
            {
                strokes.Add(new List<Point>(currentStroke)); // 현재 선을 전체 선 리스트에 추가
                currentStroke = null; // 현재 선 초기화 (다음 선 준비)
                lastPoint = null; // 마지막 점 초기화

                this.Invalidate(); // 화면 갱신
            }
        }

        // 화면을 다시 그림
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // 전체 선을 화면에 그리기
            foreach (var stroke in strokes)
            {
                DrawSmoothLine(g, stroke); // 부드럽게 그리기 위한 메소드 호출
            }

            // 현재 그리고 있는 선도 화면에 표시
            if (currentStroke != null && currentStroke.Count > 1)
            {
                DrawSmoothLine(g, currentStroke); // 부드럽게 그리기
            }
        }

        // 부드러운 선을 그리는 메소드 (Bezier Curve 사용)
        private void DrawSmoothLine(Graphics g, List<Point> stroke)
        {
            if (stroke.Count < 4) return;  // 3차 베지어 곡선에는 4개 이상의 점이 필요함

            // 선을 그리기 위해 stroke에 있는 점들을 순차적으로 처리
            for (int i = 0; i < stroke.Count - 3; i++) // 4개의 점씩 그룹화하여 3차 베지어 곡선 적용
            {
                var p0 = stroke[i];     // 시작점
                var p1 = stroke[i + 1]; // 첫 번째 제어점
                var p2 = stroke[i + 2]; // 두 번째 제어점
                var p3 = stroke[i + 3]; // 끝점

                // 3차 베지어 곡선으로 점들을 연결
                g.DrawBezier(pen, p0, p1, p2, p3);
            }

            // 마지막 3개 점을 직선으로 연결
            if (stroke.Count > 3)
            {
                var lastIndex = stroke.Count - 3;
                // 마지막 3개의 점을 하나씩 직선으로 연결
                g.DrawLine(pen, stroke[lastIndex], stroke[lastIndex + 1]);
                g.DrawLine(pen, stroke[lastIndex + 1], stroke[lastIndex + 2]);
            }
        }

        // 두 점 사이의 거리 계산
        private double GetDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }

        // 선 데이터를 NDJSON 데이터셋 형식에 맞게 변환
        public List<List<List<int>>> ToDatasetFormat()
        {
            var formattedStrokes = new List<List<List<int>>>(); // 최종 변환된 선 데이터 저장 리스트

            // 각 선(stroke)을 좌표 형식으로 변환
            foreach (var stroke in strokes)
            {
                var xCoords = new List<int>(); // X 좌표 리스트
                var yCoords = new List<int>(); // Y 좌표 리스트

                foreach (var point in stroke)
                {
                    xCoords.Add(point.X); // 각 점의 X 좌표 저장
                    yCoords.Add(point.Y); // 각 점의 Y 좌표 저장
                }

                // X와 Y 좌표 리스트를 하나의 리스트로 묶어 추가
                formattedStrokes.Add(new List<List<int>> { xCoords, yCoords });
            }

            return formattedStrokes; // NDJSON 형식에 맞는 리스트 반환
        }

        private void toolClear_Click(object sender, EventArgs e)
        {
            strokes.Clear(); // 선 리스트 초기화
            this.Invalidate(); // 화면 갱신
        }

        private void toolNext_Click(object sender, EventArgs e)
        {
            StartGame();
            this.Invalidate();
        }

        private void toolExist_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("그만하시겠어요?", "", MessageBoxButtons.YesNo) == DialogResult.Yes) Close();
        }
    }
}