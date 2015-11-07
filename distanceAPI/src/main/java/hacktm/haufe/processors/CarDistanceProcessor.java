package hacktm.haufe.processors;

import org.apache.camel.Exchange;
import org.apache.camel.Processor;

public class CarDistanceProcessor implements Processor {
	
	@Override
	public void process(Exchange exchange) throws Exception {
		String distance=((net.sf.saxon.dom.DOMNodeList) exchange.getProperty("distance")).item(0).getNodeValue();
		String val = distance.split(" km")[0];
		val=val.replace(",", "");
		
		Double dist=Double.parseDouble(val);
		Double quantum=2*6*1.12/100;
		Long price = new Long(Math.round(quantum*dist));
		String response="{\"distance\":\""+distance+"\",\"price\":\""+price+" EUR\"}";
//				+ "		String response= "Sup guys.. \"Team Not Again\" Rullllz.. .Ahhh btw:Distance by car= "+distance+" approximately "+price + "EURO!";
		exchange.getOut().setBody(response);
//		{"Date":"11/07/2015 09:19:26","Name":"Test"}
	}
}