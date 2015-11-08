package hacktm.haufe.processors;

import org.apache.camel.Exchange;
import org.apache.camel.Processor;
import org.w3c.dom.Node;

public class CarDistanceProcessor implements Processor {

	@Override
	public void process(Exchange exchange) throws Exception {
		Node item = ((net.sf.saxon.dom.DOMNodeList) exchange
				.getProperty("distance")).item(0);
		if (item == null) {
			exchange.getOut().setBody("{}");
			return;
		}

		Double dist = 0.0;
		String distance = item.getNodeValue();
		String val = distance.split(" km")[0];
		val = val.replace(",", "");

		if (val.contains("mi")) {
			val = distance.split(" mi")[0];
			val = val.replace(",", "");
			dist = 1.6 * Double.parseDouble(val);
		}

		if (dist == 0.0) {
			dist = Double.parseDouble(val);
		}
		Double quantum = 2 * 6 * 1.12 / 100;
		Long price = new Long(Math.round(quantum * dist));
		String response = "{\"distance\":\"" + distance + "\",\"price\":\""
				+ price + " EUR\"}";
		exchange.getOut().setBody(response);
	}
}