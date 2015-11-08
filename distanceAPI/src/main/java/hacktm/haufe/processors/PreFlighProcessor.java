package hacktm.haufe.processors;

import java.util.HashMap;

import org.apache.camel.Exchange;
import org.apache.camel.Processor;

public class PreFlighProcessor implements Processor {

	static final HashMap<String, String> AIPA_CODES = new HashMap<String, String>();

	static {
		AIPA_CODES.put("Timisoara", "TSR");
		AIPA_CODES.put("London", "LON");
		AIPA_CODES.put("Hampton", "AUK");
		AIPA_CODES.put("New Orleans", "MSY");

	}

	@Override
	public void process(Exchange exchange) throws Exception {

		String start = exchange.getIn().getHeader("start").toString();
		if (AIPA_CODES.get(start) != null) {
			start = AIPA_CODES.get(start);
		}
		start = start.replace(" ", "");
		start = start.trim();
		start=start.substring(0,3);
		exchange.getIn().setHeader("start", start);

		String dest = exchange.getIn().getHeader("dest").toString();
		if (AIPA_CODES.get(dest) != null) {
			dest = AIPA_CODES.get(dest);
		}
		dest = dest.replace(" ", "");
		dest = dest.trim();
		dest=dest.substring(0,3);
		exchange.getIn().setHeader("dest",dest);

	}
}