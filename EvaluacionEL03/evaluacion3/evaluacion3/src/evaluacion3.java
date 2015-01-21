import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JLabel;
import javax.swing.JTextField;
import javax.swing.JComboBox;
import javax.swing.DefaultComboBoxModel;
import javax.swing.JButton;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;


public class evaluacion3 extends JFrame implements ActionListener {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private JPanel contentPane;
	private JLabel lblMarca;
	private JLabel lblCantidad;
	private JTextField txtCantidad;
	private JComboBox cboMarca;
	private JButton btnProcesar;
	private JButton btnBorrar;
	private JScrollPane scrollPane;
	private JTextArea txtS;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					evaluacion3 frame = new evaluacion3();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public evaluacion3() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 450, 300);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		{
			lblMarca = new JLabel("Marca");
			lblMarca.setBounds(30, 50, 46, 14);
			contentPane.add(lblMarca);
		}
		{
			lblCantidad = new JLabel("Cantidad");
			lblCantidad.setBounds(30, 95, 46, 14);
			contentPane.add(lblCantidad);
		}
		{
			txtCantidad = new JTextField();
			txtCantidad.setBounds(107, 92, 86, 20);
			contentPane.add(txtCantidad);
			txtCantidad.setColumns(10);
		}
		{
			cboMarca = new JComboBox();
			cboMarca.setModel(new DefaultComboBoxModel(new String[] {"Monark", "Fratta", "Goliat", "Oxfort"}));
			cboMarca.setBounds(107, 47, 86, 20);
			contentPane.add(cboMarca);
		}
		{
			btnProcesar = new JButton("Procesar");
			btnProcesar.addActionListener(this);
			btnProcesar.setBounds(307, 46, 89, 23);
			contentPane.add(btnProcesar);
		}
		{
			btnBorrar = new JButton("Borrar");
			btnBorrar.addActionListener(this);
			btnBorrar.setBounds(307, 95, 89, 23);
			contentPane.add(btnBorrar);
		}
		{
			scrollPane = new JScrollPane();
			scrollPane.setBounds(10, 125, 398, 126);
			contentPane.add(scrollPane);
			{
				txtS = new JTextArea();
				scrollPane.setViewportView(txtS);
			}
		}
	}
	public void actionPerformed(ActionEvent arg0) {
		if (arg0.getSource() == btnBorrar) {
			do_btnBorrar_actionPerformed(arg0);
		}
		if (arg0.getSource() == btnProcesar) {
			do_btnProcesar_actionPerformed(arg0);
		}
	}
	protected void do_btnProcesar_actionPerformed(ActionEvent arg0) {
		
		//Declaracion de variables locales
				int marc, cant;
				double ic, id, ip;
				String reg;
				
				
				marc=getMarca();
				cant=getCantidad();
				ic=ImporteCompra(cant, marc);
				id=ImporteDescuento(ic, cant);
				ip=ImportePagar(ic, id);
				reg=Regalo(marc,cant);
				mostrarresultado(ic,id,ip,reg);
				
				
			}
				int getMarca(){
					return cboMarca.getSelectedIndex();		
			}
				int getCantidad(){
					return Integer.parseInt(txtCantidad.getText());
			}
				double ImporteCompra(int cant, int marc){
				switch(marc){
			    case 0:
					return cant * 399;
				case 1:
				    return cant * 320;
				case 2:
					return cant * 380;
				default:
				    return cant * 450;
			}
		}
		       double ImporteDescuento(double ic, int cant){
		    	   if (cant>3)
		    		   return ic * 0.0;
		    	   else if (cant>8)
		    		   return ic * 0.05;
		    	   else if (cant>12)
		    		   return ic * 0.1;
		    	   else 
		    		   return ic * 0.15;
		       }
		       double ImportePagar(double ic, double id){
		    	   return ic-id;   
		      }
		       
				String Regalo(int cant, int marc){
					if (marc==0 && cant>5)
						return "Paquete Aventurero";
					else if(marc==2 && cant>5)
					    return "Paquete Aventurero";
					else 
						return "Ninguno";
					
				}		
				
		           //Imprimir
					txtS.setText("Tienda " + "\n");
					txtS.append("Importe de Compra : " + ic + "\n");
					txtS.append("Importe de Descuento : " + id + "\n");
					txtS.append("Importe Pagar : " + ic + "\n");	
				}
		}


	protected void do_btnBorrar_actionPerformed(ActionEvent arg0) {
	}
}
