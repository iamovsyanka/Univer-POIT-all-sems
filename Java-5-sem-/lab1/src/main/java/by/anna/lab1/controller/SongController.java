package by.anna.lab1.controller;

import by.anna.lab1.forms.SongForm;
import by.anna.lab1.model.Song;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;

import java.util.ArrayList;
import java.util.List;

@Slf4j
@Controller
public class SongController {
    private static List<Song> songs = new ArrayList<>();

    static {
        songs.add(new Song("Run", "Hozier"));
        songs.add(new Song("Play Date", "Melanie Martinez"));
        log.info("-----------Add first data in list");
    }

    @Value("${welcome.message}")
    private String message;

    @Value("${error.message}")
    private String errorMessage;

    @GetMapping("/")
    public ModelAndView index(Model model) {
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setViewName("index");
        model.addAttribute("message", message);
        log.info("-----------add first data");

        return modelAndView;
    }

    @GetMapping("/playlist")
    public ModelAndView playlist(Model model) {
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setViewName("playlist");
        model.addAttribute("songs", songs);
        log.info("-----------Playlist");

        return modelAndView;
    }

    @GetMapping("/addSong")
    public ModelAndView showAddSongPage(Model model) {
        ModelAndView modelAndView = new ModelAndView("addSong");
        SongForm songForm = new SongForm();
        model.addAttribute("songForm", songForm);
        log.info("-----------Show Add Song Page");

        return modelAndView;
    }

    @PostMapping("/addSong")
    public ModelAndView saveSong(Model model, @ModelAttribute("songForm") SongForm songForm) {
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setViewName("playlist");
        String title = songForm.getTitle();
        String author = songForm.getAuthor();
        if (title != null && !title.isEmpty() && author != null && !author.isEmpty()) {
            var newSong = new Song(title, author);
            songs.add(newSong);
            log.info("-----------Add song");
            model.addAttribute("songs", songs);

            return new ModelAndView("redirect:/playlist");
        }
        model.addAttribute("errorMessage", errorMessage);
        modelAndView.setViewName("addSong");

        return modelAndView;
    }

    @DeleteMapping({"/deleteSong"})
    public ModelAndView deleteBook(String song) {
        for (int i = 0; i < songs.size(); i++) {
            if (songs.get(i).toString().equals(song)) {
                songs.remove(i);
                log.info("--------------Delete song");
            }
        }
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setViewName("playlist");

        return modelAndView;
    }

    @PutMapping({"/edit"})
    public ModelAndView editSong(String beforeChanges, String changes) {
        for (Song song : songs) {
            if (song.getAuthor().equals(beforeChanges)) {
                song.setAuthor(changes);
                log.info("--------------Edit song");
            }
            if (song.getTitle().equals(beforeChanges)) {
                song.setTitle(changes);
                log.info("--------------Edit song");
            }
        }

        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setViewName("playlist");

        return modelAndView;
    }
}
