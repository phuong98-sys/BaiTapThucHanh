import { TestAngularTemplatePage } from './app.po';

describe('TestAngular App', function() {
  let page: TestAngularTemplatePage;

  beforeEach(() => {
    page = new TestAngularTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
