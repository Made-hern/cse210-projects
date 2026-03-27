using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Cook Pasta", "Chef Maria", 300);
        video1.AddComment(new Comment("John", "Great recipe!"));
        video1.AddComment(new Comment("Ana", "Loved it!"));
        video1.AddComment(new Comment("Luis", "Very helpful"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("C# Basics Tutorial", "CodeMaster", 600);
        video2.AddComment(new Comment("Carlos", "Easy to understand"));
        video2.AddComment(new Comment("Sofia", "Thanks for this!"));
        video2.AddComment(new Comment("Miguel", "Very clear explanation"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Workout at Home", "FitLife", 900);
        video3.AddComment(new Comment("Laura", "Great workout"));
        video3.AddComment(new Comment("Pedro", "I feel stronger already"));
        video3.AddComment(new Comment("Diana", "Awesome routine"));
        videos.Add(video3);

        // Mostrar información
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}