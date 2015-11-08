package hacktm.haufe.processors;

import org.apache.camel.Exchange;
import org.apache.camel.Processor;

public class PreFlighProcessor implements Processor {
	
	@Override
	public void process(Exchange exchange) throws Exception {
		
		String start = exchange.getIn().getHeader("start").toString();
		if(start.equals("EDI"))
		{
			exchange.getIn().setHeader("start", "LON");
		}
		
		String dest = exchange.getIn().getHeader("dest").toString();
		if(dest.equals("EDI"))
		{
			exchange.getIn().setHeader("dest", "LON");
		}
		
	}
}