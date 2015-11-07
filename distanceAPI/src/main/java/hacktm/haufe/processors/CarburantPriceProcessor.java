package hacktm.haufe.processors;

import org.apache.camel.Exchange;
import org.apache.camel.Processor;
import org.w3c.dom.Document;

public class CarburantPriceProcessor implements Processor {
	
	@Override
	public void process(Exchange exchange) throws Exception {
//		  int lastIndexOf = exchange.getIn().toString().lastIndexOf("Super 95 in Europe");
//		  String sdf= exchange.getIn().toString().substring(lastIndexOf, lastIndexOf+100);
		  
//		  String string = exchange.getIn().toString();
//		  
//		  exchange.getIn().toString().split("Romania");
//		
//		String distance=((net.sf.saxon.dom.DOMNodeList) exchange.getProperty("distance")).item(0).getNodeValue();
//		String val = distance.split(" km")[0];
//		val=val.replace(",", "");
//		
//		Double dist=Double.parseDouble(val);
//		
//		String response= "Sup guys.. \"Team Not Again\" Rullllz.. .Ahhh btw:Distance by car= "+distance+" approximately "+(0.075*dist) + "EURO!";
//		exchange.getOut().setBody(response);
	}
}