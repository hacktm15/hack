package hacktm.haufe;

import org.apache.camel.Exchange;
import org.apache.camel.Processor;

public class ResponseProcessor implements Processor {
	
	@Override
	public void process(Exchange exchange) throws Exception {
		String distance=((net.sf.saxon.dom.DOMNodeList) exchange.getProperty("distance")).item(0).getNodeValue();
		String val = distance.split(" km")[0];
		val=val.replace(",", "");
		
		Double dist=Double.parseDouble(val);
		
		String response= "Sup guys.. \"Team Not Again\" Rullllz.. .Ahhh btw:Distance by car= "+distance+" approximately "+(0.075*dist) + "EURO!";
		exchange.getOut().setBody(response);
	}
}