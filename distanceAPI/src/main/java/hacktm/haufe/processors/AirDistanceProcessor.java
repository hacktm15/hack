package hacktm.haufe.processors;

import java.util.Iterator;

import org.apache.camel.Exchange;
import org.apache.camel.Processor;
import org.json.JSONArray;
import org.json.JSONObject;
import org.json.XML;

public class AirDistanceProcessor implements Processor {

	@Override
	public void process(Exchange exchange) throws Exception {

		JSONObject jsonObject = XML.toJSONObject(exchange.getIn().getBody(
				String.class));
		JSONObject result = new JSONObject();

		JSONObject jsValue = getJSValue("BrowseQuotesResponseAPIDto",
				jsonObject);
		JSONObject jsValueCarrier = getJSValue("Carriers", jsValue);
		jsValue = getJSValue("Quotes", jsValue);
		if (jsValue != null) {

			jsValue = getJSValue("QuoteDto", jsValue);
			Long price = (Long) jsValue.get("MinPrice");
			result.put("price", price + " EUR");

			jsValue = getJSValue("OutboundLeg", jsValue);
			String departureDate = (String) jsValue.get("DepartureDate");
			result.put("departureDate", departureDate);

			JSONObject carrierId = getJSValue("CarrierIds", jsValue);

			try {
				jsValueCarrier = getJSValue("CarriersDto", jsValueCarrier);
			} catch (ClassCastException ex) {
				JSONArray jsonArray = jsValueCarrier
						.getJSONArray("CarriersDto");

				Iterator<Object> jsonIter = jsonArray.iterator();

				while (jsonIter.hasNext()) {
					JSONObject js = (JSONObject) jsonIter.next();

					if (carrierId.get("int").equals(js.get("CarrierId"))) {
						result.put("flightCompany", js.get("Name"));
					}
				}

			}
		}
		exchange.getOut().setHeader(Exchange.CONTENT_TYPE, "application/json");
		exchange.getOut().setBody(result.toString());
	}

	private JSONObject getJSValue(String input, JSONObject jo) {
		JSONObject jos = jo;
		try {
			jos = ((JSONObject) jo.get(input));

		} catch (ClassCastException ex) {

			try {
				JSONArray jsonArray = jos.getJSONArray(input);
				Iterator<Object> jsonIter = jsonArray.iterator();

				while (jsonIter.hasNext()) {
					return (JSONObject) jsonIter.next();

				}
			} catch (org.json.JSONException exxx) {
				return null;
			}
		}

		return jos;

	}
}