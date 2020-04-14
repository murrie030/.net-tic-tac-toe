package myswingapp;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.border.*;

public class TicTacToe extends JFrame implements ActionListener {
	private JButton b1, b2, b3, b4, b5, b6, b7, b8, b9;
	private int beurt = 0;
	private String plaatje = "";

	public TicTacToe() {
		JPanel p = new JPanel();
		p.setLayout(new GridLayout(3, 3, 5, 5));
		p.setBorder(new EmptyBorder(5, 5, 5, 5));
		add(p, BorderLayout.CENTER);

		b1 = new JButton("");
		p.add(b1);
		b1.addActionListener(this);
		b2 = new JButton("");
		p.add(b2);
		b2.addActionListener(this);
		b3 = new JButton("");
		p.add(b3);
		b3.addActionListener(this);
		b4 = new JButton("");
		p.add(b4);
		b4.addActionListener(this);
		b5 = new JButton("");
		p.add(b5);
		b5.addActionListener(this);
		b6 = new JButton("");
		p.add(b6);
		b6.addActionListener(this);
		b7 = new JButton("");
		p.add(b7);
		b7.addActionListener(this);
		b8 = new JButton("");
		p.add(b8);
		b8.addActionListener(this);
		b9 = new JButton("");
		p.add(b9);
		b9.addActionListener(this);

		Font f = new Font("SansSerif", Font.BOLD, 20);
		b1.setFont(f);
		b2.setFont(f);
		b3.setFont(f);
		b4.setFont(f);
		b5.setFont(f);
		b6.setFont(f);
		b7.setFont(f);
		b8.setFont(f);
		b9.setFont(f);

		setSize(200, 200);
		setVisible(true);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
	}

	public void actionPerformed(ActionEvent event) {
		if (beurt % 2 == 1) {
			plaatje = "X";
		} else {
			plaatje = "O";
		}

		JButton ingedrukt = (JButton) event.getSource();
		if (ingedrukt.getText() == "") {
			ingedrukt.setText(plaatje);
			beurt++;
		}

		if 	(!(bepaalWinnaar(b1, b2, b3) ||
			bepaalWinnaar(b4, b5, b6) ||
			bepaalWinnaar(b7, b8, b9) ||
			bepaalWinnaar(b1, b5, b9) ||
			bepaalWinnaar(b3, b5, b7) ||
			bepaalWinnaar(b1, b4, b7) ||
			bepaalWinnaar(b2, b5, b8) ||
			bepaalWinnaar(b3, b6, b9)) && beurt == 9) {
				JOptionPane.showMessageDialog(null, "Jammer! Niemand wint.",
					"Er is GEEN winnaar!", JOptionPane.PLAIN_MESSAGE);
				maakLeeg();	
		}
	}

	public boolean bepaalWinnaar(JButton a, JButton b, JButton c) {
		if (a.getText() == b.getText() && a.getText() == c.getText()
				&& !a.getText().equals("")) {
			JOptionPane.showMessageDialog(null, "Gefeliciteerd! Speler "
					+ plaatje + " wint.", "Er is een winnaar!",
					JOptionPane.PLAIN_MESSAGE);
			maakLeeg();
			return true;
		}
		return false;
	}

	public void maakLeeg() {
		b1.setText("");
		b2.setText("");
		b3.setText("");
		b4.setText("");
		b5.setText("");
		b6.setText("");
		b7.setText("");
		b8.setText("");
		b9.setText("");
		beurt = 0;
	}

	public static void main(String[] args) {
		TicTacToe t = new TicTacToe();
	}
}
