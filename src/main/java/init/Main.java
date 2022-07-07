package init;

import view.DobbleGame;

import javax.swing.*;

public class Main {
    public static void main(String[] args) {

        SwingUtilities.invokeLater(new Runnable() {
            @Override
            public void run() {
                DobbleGame dobbleGame = new DobbleGame();
                dobbleGame.setSize(300,300);
                dobbleGame.setVisible(true);
            }
        });

    }
}