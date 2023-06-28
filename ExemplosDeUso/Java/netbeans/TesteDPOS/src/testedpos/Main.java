/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package testedpos;

import com.sun.jna.Native;

/**
 *
 * @author jmachado
 */
public class Main {

    /**
     * @param args the command line arguments
     */
       
    public static void main(String[] args) {
        try {
            int Ret;
            TefManager tef = new TefManager();
            Ret=0;
            String sValor = "000000000200";
            String sCupomFiscal = "000321";

            byte[] bNSU = new byte[7];
                   
            tef.SetSemtelas(); // (Chamar para setar operações sem telas)
            Ret = tef.TransacaoCartaoCrediario(sValor, sCupomFiscal, bNSU);
          
            String sNSU = Native.toString(bNSU);

            System.out.println("Retorno: " + Ret);
            System.out.println("NSU: " + sNSU);

        } catch (Exception ex) {
            ex.printStackTrace();
        }
        System.exit(0);
    }
}


