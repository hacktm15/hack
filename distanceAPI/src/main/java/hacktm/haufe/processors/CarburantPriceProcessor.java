package hacktm.haufe.processors;

import org.apache.camel.Exchange;
import org.apache.camel.Processor;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Node;

public class CarburantPriceProcessor implements Processor {

	private final Double EUR = 4.4523;

	@Override
	public void process(Exchange exchange) throws Exception {

		String eurPrice = "1.12";

		try {

			String string = exchange.getIn().getBody(String.class);
			Document parse = Jsoup.parse(string);
			Node node = parse.childNode(1);
			Node node2 = node.childNode(2);
			Node childNode = node2.childNode(1);
			String price = childNode.childNode(7).childNode(19).childNode(1)
					.childNode(6).childNode(0).toString();
			price = price.trim().split(" ")[0];
			Double priceD = Double.parseDouble(price);
			 eurPrice = String.format("%.2f", priceD / EUR);
		} catch (Exception ex) {
			System.out.println("site changed");
		}
		exchange.getOut().setBody(eurPrice);
	}
}