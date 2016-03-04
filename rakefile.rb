require 'albacore'

SOLUTION_DIR = "cloudshop/cloudshop.sln"
PACKAGES_DIR = "packages"
NUGET_DIR = "c:/program files (x86)/nuget/nuget.exe"
WEB_PROJECT_BIN_DIR = "bin/"
INTEGRATION_TEST_PROJECT = "cloudshop/cloudshop.test.acceptance"

task :default => [:build]

desc "Buildling"
build :build do |b|
  b.sln = SOLUTION_DIR
  b.target = ['Clean', 'Rebuild']
  b.prop 'Configuration', 'Release'
end

desc "Transforming Test Config"
task :transformTestConfig, :environment do |t, args|
    FileUtils.cp "#{INTEGRATION_TEST_PROJECT}/config/app.#{args.environment}.config", "#{INTEGRATION_TEST_PROJECT}/bin/#{INTEGRATION_TEST_PROJECT}.dll.config"
end