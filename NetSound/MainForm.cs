using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using NAudio.Wave;
using NAudio.CoreAudioApi;

namespace NetSound
{
    public partial class MainForm : Form
    {

        
        private bool connected;
        
        //поток для нашей речи
        WaveIn audioinput;
        
        //поток для удаленной речи
        WaveOut audiooutput;
        
        //буфферный поток для передачи через сеть
        BufferedWaveProvider bufferStream;
        
        //нить для приема входящих сообщений
        Thread in_thread;
        
        //нить для передачи сообщений
        Thread out_thread;

        //сокет для отправки
        Socket sendingSocket;

        //сокет для приема 
        Socket listeningSocket;


        //взрыв мозга. не путать потоки воспроизведения аудио и его отправки

        public MainForm()
        {
            InitializeComponent();

            //создаем поток для записи нашей речи
            audioinput = new WaveIn();
            //определяем его формат - частота дискретизации 8000 Гц, ширина сэмпла - 16 бит, 1 канал - моно
            audioinput.WaveFormat = new WaveFormat(8000, 16, 1);
            //добавляем код обработки нашего голоса, поступающего на микрофон
            audioinput.DataAvailable += Voice_Input;
            //создаем поток для прослушивания входящего звука
            audiooutput = new WaveOut();
            //создаем поток для буферного потока и определяем у него такой же формат как и потока с микрофона
            bufferStream = new BufferedWaveProvider(new WaveFormat(8000, 16, 1));
            //привязываем поток входящего звука к буферному потоку
            audiooutput.Init(bufferStream);
           
            //сокеты для отправки звука
            sendingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);           
            listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            connected = true;



        }

        //Обработка нашего голоса
        private void Voice_Input(object sender, WaveInEventArgs e)
        {
            try
            {
                //Подключаемся к удаленному адресу
                IPEndPoint remote_point = new IPEndPoint(IPAddress.Parse(ipAddressTextBox.Text), 5555);
                //посылаем байты, полученные с микрофона на удаленный адрес
                sendingSocket.SendTo(e.Buffer, remote_point);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Прослушивание входящих подключений
        private void Listening()
        {
            //Прослушиваем по адресу
            IPEndPoint localIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5555);
            listeningSocket.Bind(localIP);
            //начинаем воспроизводить входящий звук
            audiooutput.Play();
            //адрес, с которого пришли данные
            EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0); 
//            EndPoint remoteIp = new IPEndPoint(IPAddress.Parse(ipAddressTextBox.Text), 5555); 

            while (connected == true)
            {
                try
                {
                    //промежуточный буфер
                    byte[] data = new byte[65535];
                    //получено данных
                    int received = listeningSocket.ReceiveFrom(data, ref remoteIp);
                    //добавляем данные в буфер, откуда output будет воспроизводить звук
                    bufferStream.AddSamples(data, 0, received);
                }
                catch (SocketException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void startTalkButton_Click(object sender, EventArgs e)
        {

            //создаем поток для прослушивания
            in_thread = new Thread(new ThreadStart(Listening));
            //запускаем его
            in_thread.Start();


            audioinput.StartRecording();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            connected = false;
            listeningSocket.Close();
            listeningSocket.Dispose();

            sendingSocket.Close();
            sendingSocket.Dispose();
            if (audiooutput != null)
            {
                audiooutput.Stop();
                audiooutput.Dispose();
                audiooutput = null;
            }
            if (audioinput != null)
            {
                audioinput.Dispose();
                audioinput = null;
            }
            bufferStream = null;
        }
    }
}
